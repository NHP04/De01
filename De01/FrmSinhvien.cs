using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace De01
{
    public partial class FrmSinhvien : Form
    {
        public FrmSinhvien()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FrmSinhvien_Load);

        }

        private void FrmSinhvien_Load(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void AddButton(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtMaSV.Text, txtHoTen.Text, dateTimePicker.Value.ToShortDateString(), comboBoxClass.SelectedItem?.ToString());

            // Xóa nội dung các ô nhập liệu sau khi thêm
            txtMaSV.Clear();
            txtHoTen.Clear();
            dateTimePicker.Value = DateTime.Now;
            comboBoxClass.SelectedIndex = -1;
        }



        private void Deletebutton(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }


        private void Editbutton(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Nếu ô nhập liệu không rỗng, cập nhật giá trị vào ô tương ứng trong DataGridView
                if (!string.IsNullOrEmpty(txtMaSV.Text))
                {
                    dataGridView1.CurrentRow.Cells[0].Value = txtMaSV.Text;
                }

                if (!string.IsNullOrEmpty(txtHoTen.Text))
                {
                    dataGridView1.CurrentRow.Cells[1].Value = txtHoTen.Text;
                }

                if (dateTimePicker.Value != DateTime.MinValue) // Đảm bảo dateTimePicker có giá trị hợp lệ
                {
                    dataGridView1.CurrentRow.Cells[2].Value = dateTimePicker.Value.ToShortDateString();
                }

                if (comboBoxClass.SelectedItem != null)
                {
                    dataGridView1.CurrentRow.Cells[3].Value = comboBoxClass.SelectedItem.ToString();
                }
            }
        }




        private void Savebutton(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu đã được lưu tạm thời.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void Exit(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Kiểm tra xem người dùng đã chọn Yes hay No
            if (result == DialogResult.Yes)
            {
                // Đóng form nếu chọn Yes
                this.Close();
            }
            // Nếu chọn No, form sẽ không đóng và tiếp tục hoạt động
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Điền thông tin vào các ô nhập liệu khi chọn một hàng trong DataGridView
                txtMaSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateTimePicker.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);

                comboBoxClass.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                // Bật nút Sửa và Xóa khi có sinh viên được chọn
                button2.Enabled = true; // Nút Sửa
                button3.Enabled = true; // Nút Xóa
            }
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void KhongSavebutton(object sender, EventArgs e)
        {
 
                // Xóa nội dung các ô nhập liệu, đặt về trạng thái ban đầu
                txtMaSV.Clear();
                txtHoTen.Clear();
                dateTimePicker.Value = DateTime.Now;
                comboBoxClass.SelectedIndex = -1;

                // Tắt nút Sửa và Xóa (nếu có) để người dùng không thực hiện các thao tác này
                button2.Enabled = false; // Nút Sửa
                button3.Enabled = false; // Nút Xóa

                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Thông tin đã được xóa và không có thay đổi nào được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        private void Timsinhvien(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ ô nhập liệu
            string searchKeyword = txtSearch.Text.ToLower();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Biến để kiểm tra xem có tìm thấy sinh viên không
            bool found = false;

            // Duyệt qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string maSV = row.Cells[0].Value.ToString().ToLower();
                    string hoTen = row.Cells[1].Value.ToString().ToLower();

                    // Kiểm tra nếu mã sinh viên hoặc họ tên chứa từ khóa tìm kiếm
                    if (maSV.Contains(searchKeyword) || hoTen.Contains(searchKeyword))
                    {
                        // Tô sáng hàng tìm thấy
                        row.Selected = true;
                        found = true;
                        break;
                    }
                }
            }

            // Hiển thị thông báo nếu không tìm thấy sinh viên
            if (!found)
            {
                MessageBox.Show("Không tìm thấy sinh viên với thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

