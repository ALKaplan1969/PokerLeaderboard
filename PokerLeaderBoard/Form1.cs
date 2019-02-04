using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure;
using Infrastructure.DataAccess;
using Infrastructure.Models;

namespace PokerLeaderBoard
{
    public partial class Form1 : Form
    {
        private BindingSource playersBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "Player Id";
            column.ReadOnly = true;
            dgPlayer.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "Name";
            column2.Name = "Player Name";
            column2.ReadOnly = false;
            dgPlayer.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "Winnings";
            column3.Name = "Winnings";
            column3.DefaultCellStyle.Format = "c";
            column3.ReadOnly = false;
            dgPlayer.Columns.Add(column3);

            DataGridViewColumn cbcolumn = new DataGridViewCheckBoxColumn();
            cbcolumn.DataPropertyName = "IsMedian";
            cbcolumn.Name = "Cloest to Median";
            cbcolumn.ReadOnly = true;
            dgPlayer.Columns.Add(cbcolumn);

            DataGridViewColumn cbcolumn2 = new DataGridViewCheckBoxColumn();
            cbcolumn2.DataPropertyName = "IsMean";
            cbcolumn2.Name = "Cloest to Mean";
            cbcolumn2.ReadOnly = true;
            dgPlayer.Columns.Add(cbcolumn2);

            DataGridViewButtonColumn cbEditButton = new DataGridViewButtonColumn();
            cbEditButton.Name = "Edit";
            cbEditButton.HeaderText = string.Empty;
            cbEditButton.Text = "Edit";
            cbEditButton.ReadOnly = true;
            cbEditButton.UseColumnTextForButtonValue = true;
            dgPlayer.Columns.Add(cbEditButton);

            DataGridViewButtonColumn cbSaveButton = new DataGridViewButtonColumn();
            cbSaveButton.Name = "Save";
            cbSaveButton.HeaderText = string.Empty;
            cbSaveButton.Text = "Save";
            cbSaveButton.ReadOnly = true;
            cbSaveButton.UseColumnTextForButtonValue = true;
            cbSaveButton.Visible = false;
            dgPlayer.Columns.Add(cbSaveButton);

            DataGridViewButtonColumn cbCancelButton = new DataGridViewButtonColumn();
            cbCancelButton.Name = "Cancel";
            cbCancelButton.HeaderText = string.Empty;
            cbCancelButton.Text = "Cancel";
            cbCancelButton.ReadOnly = true;
            cbCancelButton.Visible = false;
            cbCancelButton.UseColumnTextForButtonValue = true;
            dgPlayer.Columns.Add(cbCancelButton);

            DataGridViewButtonColumn cbDeleteButton = new DataGridViewButtonColumn();
            cbDeleteButton.Name = "Delete";
            cbDeleteButton.HeaderText = string.Empty;
            cbDeleteButton.Text = "Delete";
            cbDeleteButton.ReadOnly = true;
            cbDeleteButton.Visible = true;
            cbDeleteButton.UseColumnTextForButtonValue = true;
            dgPlayer.Columns.Add(cbDeleteButton);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var leaderBoardProvider = new LeaderBoardProvider();

                List<Player> playerList = (List<Player>)playersBindingSource.DataSource;

                decimal winnings = 0;
                decimal.TryParse(txtWinnings.Text, out winnings);
                LeaderBoard leaderBoard = leaderBoardProvider.AddPlayer(txtPlayerName.Text, winnings, playerList);

                lblMedian.Text = string.Format("{0:C}", leaderBoard.Median);    
                lblMean.Text = string.Format("{0:C}", leaderBoard.Mean);    

                playersBindingSource = new BindingSource();
                playersBindingSource.DataSource = leaderBoard.Players;
                dgPlayer.DataSource = playersBindingSource;
                dgPlayer.Update();
                dgPlayer.Refresh();

                txtPlayerName.Text = string.Empty;
                txtWinnings.Text = string.Empty;
                pnlAddPlayer.Visible = false;
                btnAddPlayer.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var leaderBoardProvider = new LeaderBoardProvider();
            var leaderBoard = leaderBoardProvider.GetLeaderBoard();

            lblMedian.Text = string.Format("{0:C}", leaderBoard.Median);  
            lblMean.Text = string.Format("{0:C}", leaderBoard.Mean);  

            if (leaderBoard.Players != null)
            {
                playersBindingSource.DataSource = leaderBoard.Players;
                dgPlayer.DataSource = playersBindingSource;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "There are no players to display";

            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            pnlAddPlayer.Visible = true;
            btnAddPlayer.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlAddPlayer.Visible = false;
            btnAddPlayer.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void dgPlayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((e.RowIndex >= 0) &&
                (e.ColumnIndex == dgPlayer.Columns["Edit"].Index
                || e.ColumnIndex == dgPlayer.Columns["Save"].Index
                || e.ColumnIndex == dgPlayer.Columns["Cancel"].Index
                || e.ColumnIndex == dgPlayer.Columns["Delete"].Index))
            {
                DataGridViewCell colName = dgPlayer.Rows[e.RowIndex].Cells["Player Name"];
                DataGridViewCell colWinnings = dgPlayer.Rows[e.RowIndex].Cells["Winnings"];

                
                if (e.ColumnIndex == dgPlayer.Columns["Cancel"].Index)
                {
                    dgPlayer.Columns["Edit"].Visible = true;
                    dgPlayer.Columns["Save"].Visible = false;
                    dgPlayer.Columns["Cancel"].Visible = false;

                    //revert changes to orignal amounts
                    colWinnings.Value = lblOrigWinnings.Text;

                    colName.ReadOnly = true;
                    colWinnings.ReadOnly = true;
                    dgPlayer.Rows[e.RowIndex].ReadOnly = true;
                    dgPlayer.ReadOnly = true;
                    return;
                }

                if (e.ColumnIndex == dgPlayer.Columns["Save"].Index)
                {
                    try
                    {
                        var leaderBoardProvider = new LeaderBoardProvider();
                        var player = (Player)dgPlayer.Rows[e.RowIndex].DataBoundItem;
                        List<Player> playerList = (List<Player>)playersBindingSource.DataSource;

                        var leaderBoard = leaderBoardProvider.UpdatePlayer(player, playerList);
                        lblMedian.Text = string.Format("{0:C}", leaderBoard.Median); 
                        lblMean.Text = string.Format("{0:C}", leaderBoard.Mean);  

                        playersBindingSource = new BindingSource();
                        playersBindingSource.DataSource = leaderBoard.Players;
                        dgPlayer.DataSource = playersBindingSource;
                        dgPlayer.Update();
                        dgPlayer.Refresh();

                        dgPlayer.Columns["Edit"].Visible = true;
                        dgPlayer.Columns["Delete"].Visible = true;
                        dgPlayer.Columns["Save"].Visible = false;
                        dgPlayer.Columns["Cancel"].Visible = false;

                        colWinnings.ReadOnly = true;
                        dgPlayer.Rows[e.RowIndex].ReadOnly = true;
                        dgPlayer.ReadOnly = true;
                        return;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = ex.Message;
                    }

                }

                if (e.ColumnIndex == dgPlayer.Columns["Delete"].Index)
                {
                    try
                    {
                        string message = "Are you sure you want to delete this record?";
                        string caption = "Delete Player";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            var leaderBoardProvider = new LeaderBoardProvider();
                            var player = (Player)dgPlayer.Rows[e.RowIndex].DataBoundItem;
                            List<Player> playerList = (List<Player>)playersBindingSource.DataSource;

                            var leaderBoard = leaderBoardProvider.DeletePlayer(player, playerList);

                            if ((leaderBoard.Players == null) ||( leaderBoard.Players.Count == 0))
                            {
                                lblMedian.Text = "0";
                                lblMean.Text = "0";
                                //leaderBoard = new LeaderBoard();
                                leaderBoard.Players = new List<Player>();
                            }
                            else
                            {
                                lblMedian.Text = string.Format("{0:C}", leaderBoard.Median); 
                                lblMean.Text = string.Format("{0:C}", leaderBoard.Mean);  
                            }
                            playersBindingSource = new BindingSource();
                            playersBindingSource.DataSource = leaderBoard.Players;
                            dgPlayer.DataSource = playersBindingSource;
                            dgPlayer.Update();
                            dgPlayer.Refresh();

                            dgPlayer.Columns["Edit"].Visible = true;
                            dgPlayer.Columns["Save"].Visible = false;
                            dgPlayer.Columns["Cancel"].Visible = false;
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = ex.Message;
                    }
                }

                lblOrigWinnings.Text = colWinnings.Value.ToString();
                dgPlayer.ReadOnly = false;
                dgPlayer.Rows[e.RowIndex].ReadOnly = false;
                colWinnings.ReadOnly = false;

                dgPlayer.Columns["Edit"].Visible = false;
                dgPlayer.Columns["Delete"].Visible = false;
                dgPlayer.Columns["Save"].Visible = true;
                dgPlayer.Columns["Cancel"].Visible = true;
            }
            else
            {
                return;
            }

        }

        private void txtWinnings_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtWinnings, "");
        }

        private void txtWinnings_Validating(object sender, CancelEventArgs e)
        {
            decimal winnings = 0;
            if (!decimal.TryParse(txtWinnings.Text, out winnings))
            {
                e.Cancel = true;
                txtWinnings.Select(0, txtWinnings.Text.Length);
                errorProvider1.SetError(txtWinnings, "Not a valid winning amount");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveData()
        {
            var leaderBoard = new LeaderBoard()
            {
                Mean = Parse(lblMedian.Text),
                Median = Parse(lblMedian.Text),
                Players = (List<Player>)playersBindingSource.DataSource
            };
            LeaderBoardProvider leaderBoardProvider = new LeaderBoardProvider();
            leaderBoardProvider.SaveLeaderBoard(leaderBoard);
        }

        public static decimal Parse(string input)
        {
            return decimal.Parse(Regex.Replace(input, @"[^\d.]", ""));
        }
    }
}
