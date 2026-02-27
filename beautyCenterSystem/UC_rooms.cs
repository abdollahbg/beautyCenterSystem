using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_rooms : UserControl
    {
        private readonly RoomRepository _roomRepo;
        public UC_rooms()
        {
            InitializeComponent();
            _roomRepo = new RoomRepository(new DbConnectionFactory());


        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddRoom.FlatStyle = FlatStyle.Flat;
                btnAddRoom.FlatAppearance.BorderSize = 1;
                btnAddRoom.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddRoom.BackColor = Color.White;
            });
            dgvRooms.ContextMenuStrip = contextMenuStrip1;
            await LoadRooms();
            FormatGrid();
        }

        public async Task LoadRooms()
        {
            var rooms = await _roomRepo.GetAllAsync();
            dgvRooms.DataSource = rooms.ToList();
        }

        private void FormatGrid()
        {
            if (dgvRooms.Columns.Count > 0)
            {
                dgvRooms.Columns["RoomID"].Visible = false;
                dgvRooms.Columns["RoomName"].HeaderText = "اسم الغرفة";
                dgvRooms.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void dgvRooms_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvRooms.ClearSelection();
                dgvRooms.Rows[e.RowIndex].Selected = true;
            }
        }

        private async void dgvRooms_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var room = dgvRooms.Rows[e.RowIndex].DataBoundItem as Room;
            if (room != null)
            {
                if (string.IsNullOrWhiteSpace(room.RoomName))
                {
                    MessageBox.Show("لا يمكن ترك اسم الغرفة فارغاً");
                    await LoadRooms();
                    return;
                }

                await _roomRepo.UpdateAsync(room);
            }
        }



        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null) return;
            var room = dgvRooms.CurrentRow.DataBoundItem as Room;

            var result = MessageBox.Show($"هل أنت متأكد من حذف {room.RoomName}؟\nتنبيه: قد يؤثر هذا على الخدمات المرتبطة بها.",
                                       "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                await _roomRepo.DeleteAsync(room.RoomID);
                await LoadRooms();
            }
        }

        private async  void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddRoomForm())
            {
                AppTheme.Apply(addForm);

                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadRooms();

                }

            }
        }
    }
}

