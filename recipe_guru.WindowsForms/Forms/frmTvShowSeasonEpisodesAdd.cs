﻿using recipe_guru.WinUI;
using recipe_guru.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmTvShowSeasonEpisodesAdd : Form
    {
        private APIService _serviceTvshowSeason = new APIService("TvshowSeason");
        private APIService _serviceTvshowSeasonEpisode = new APIService("TvshowSeasonEpisode");

        private MovieAndTvshow MTVS;

        public frmTvShowSeasonEpisodesAdd(MovieAndTvshow MTVS)
        {
            this.MTVS = MTVS;
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            await LoadSeasons();
            await LoadSeasonsAdd();
            await LoadEpisodes();
        }

        private async void btnNewSeason_Click(object sender, EventArgs e)
        {
            TvshowSeasonUpsertRequest request = new TvshowSeasonUpsertRequest
            {
                Finished = chkFinished.Checked,
                MovieAndTvshowId = MTVS.Id,
                SeasonName = txtSeasonName.Text
            };
            await _serviceTvshowSeason.Insert<Data.Model.TvshowSeason>(request);
            await LoadSeasons();
            await LoadSeasonsAdd();
            await LoadEpisodes();
            txtSeasonName.Text = "";
        }

        private async Task LoadSeasons()
        {
            var list = await _serviceTvshowSeason.GetAll<List<Data.Model.TvshowSeason>>(new TvshowSeasonSearchRequest
            {
                MovieAndTvshowId = MTVS.Id
            });
            cmbSeasons.ValueMember = "Id";
            cmbSeasons.DisplayMember = "SeasonName";
            cmbSeasons.DataSource = list; 
        }

        private async Task LoadSeasonsAdd()
        {
            var list = await _serviceTvshowSeason.GetAll<List<Data.Model.TvshowSeason>>(new TvshowSeasonSearchRequest
            {
                MovieAndTvshowId = MTVS.Id
            });
            cmbSeasonAdd.ValueMember = "Id";
            cmbSeasonAdd.DisplayMember = "SeasonName";
            cmbSeasonAdd.DataSource = list;
        }

        private async Task LoadEpisodes()
        {
            TvshowSeasonEpisodeSearchRequest request = new TvshowSeasonEpisodeSearchRequest();
            var idSeason = cmbSeasons.SelectedValue;
            if (idSeason != null)
            {

                if (int.TryParse(idSeason.ToString(), out int SeasonId))
                {
                    request.TvshowSeasonId = SeasonId;
                }

                var list = await _serviceTvshowSeasonEpisode.GetAll<List<Data.Model.TvshowSeasonEpisode>>(request);
                list = list.OrderBy(x => x.EpisodeNumber).ToList();

                List<frmTvShowSeasonEpisodeVM> vm = new List<frmTvShowSeasonEpisodeVM>();
                foreach (var x in list)
                {
                    frmTvShowSeasonEpisodeVM nl = new frmTvShowSeasonEpisodeVM
                    {
                        Id = x.Id,
                        EpisodeName = x.EpisodeName,
                        AirDate = x.AirDate,
                        EpisodeNumber = (int)x.EpisodeNumber
                    };
                    vm.Add(nl);
                }

                dgvEpisodes.DataSource = vm;
            }
        }

        private async void btnAddEpisode_Click(object sender, EventArgs e)
        {
            TvshowSeasonEpisodeUpsertRequest request = new TvshowSeasonEpisodeUpsertRequest
            {
                EpisodeName = txtEpisodeName.Text,
                AirDate = dtpAirDate.Value,
                EpisodeNumber = int.Parse(txtEpNumber.Text),
                TvshowId = MTVS.Id
            };

            var idSeason = cmbSeasonAdd.SelectedValue;

            if(int.TryParse(idSeason.ToString(),out int SeasonId))
            {
                request.TvshowSeasonId = SeasonId;
                cmbSeasons.SelectedValue = cmbSeasonAdd.SelectedValue;
            }

            await _serviceTvshowSeasonEpisode.Insert<Data.Model.TvshowSeasonEpisode>(request);
            await LoadSeasons();
            await LoadEpisodes();

            txtEpisodeName.Text = "";
        }

        private async void cmbSeasons_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            await LoadEpisodes();
        }

        private async void dgvEpisodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTvShowSeasonEpisodeVM item = dgvEpisodes.SelectedRows[0].DataBoundItem as frmTvShowSeasonEpisodeVM;
            DialogResult result = MessageBox.Show("Do you want do delete this record?", "Warining", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var MTVS = await _serviceTvshowSeasonEpisode.Delete<TvshowSeasonEpisode>(item.Id);
                await LoadEpisodes();
            }
        }
    }
}
