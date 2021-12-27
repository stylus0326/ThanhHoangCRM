using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmNganHangChinh : DevExpress.XtraEditors.XtraForm
    {
        D_NGANHANGSUDUNG _NGANHANG = new D_NGANHANGSUDUNG();
        public frmNganHangChinh()
        {
            InitializeComponent();
            //GVNH.ValidatingEditor += GVNH_ValidatingEditor;//cập nhật
            //GVNH.ValidateRow += GVNH_ValidateRow;//thêm mới
            //GVNH.InvalidRowException += GVNH_InvalidRowException;//Tắt popup thông báo lỗi thêm mới
            Load += frmNganHangChinh_Load;
        }

        private void frmNganHangChinh_Load(object sender, EventArgs e)
        {
            BS_NGANHANG.DataSource = _NGANHANG.DuLieu();
        }

        #region Ngân hàng
        private void GVNH_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void GVNH_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            O_NGANHANGSUDUNG fR = (O_NGANHANGSUDUNG)view.GetFocusedRow();
            if (fR != null)
            {
                if ((fR.KyHieu ?? "").Length < 2 || (fR.KyHieu ?? "").Length > 5)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["KyHieu"], "Nhập 2-5 kí tự");
                }
                else if (_NGANHANG.KiemTraTonTai(fR.ID, "KyHieu", fR.KyHieu))
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["KyHieu"], "Ký hiệu ngân hàng đã tồn tại");
                }

                if ((fR.KyHieu ?? "").Length < 2 || (fR.KyHieu ?? "").Length > 5)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TenTat"], "Nhập 2-5 kí tự");
                }
                else if (_NGANHANG.KiemTraTonTai(fR.ID, "TenTat", fR.KyHieu))
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TenTat"], "Tên tắt ngân hàng đã tồn tại");
                }

                if ((fR.TenDayDu ?? "").Length < 3 || (fR.TenDayDu ?? "").Length > 100)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TenDayDu"], "Nhập 3-100  kí tự");
                }
                else if (_NGANHANG.KiemTraTonTai(fR.ID, "TenDayDu", fR.TenDayDu))
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TenDayDu"], "Tên ngân hàng đã tồn tại");
                }

                if (!e.Valid)
                    return;
                else if (fR.ID == 0)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("TenDayDu", fR.TenDayDu);
                    dic.Add("KyHieu", fR.KyHieu);
                    long CapNhatNum = _NGANHANG.ThemMoi(dic, true);
                    if (CapNhatNum > 0)
                        view.SetRowCellValue(e.RowHandle, view.Columns["ID"], CapNhatNum);
                    else
                    {
                        e.Valid = false;
                        view.SetColumnError(view.Columns["ID"], "Thêm không thành công");
                        return;
                    }
                }
            }
        }

        private void GVNH_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            O_NGANHANGSUDUNG fR = (O_NGANHANGSUDUNG)view.GetFocusedRow();
            if (fR != null)
            {
                object arow = (e.Value ?? "");
                switch (view.FocusedColumn.FieldName)
                {
                    case "KyHieu":
                        if (arow.ToString().Length < 2 || arow.ToString().Length > 5)
                        {
                            e.Valid = false;
                            e.ErrorText = "Nhập 2-5 kí tự";
                        }
                        else if (_NGANHANG.KiemTraTonTai(fR.ID, view.FocusedColumn.FieldName, arow))
                        {
                            e.Valid = false;
                            e.ErrorText = "Ký hiệu ngân hàng đã tồn tại";
                        }
                        break;
                    case "TenDayDu":
                        if (arow.ToString().Length < 3 || arow.ToString().Length > 100)
                        {
                            e.Valid = false;
                            e.ErrorText = "Nhập 3-100 kí tự";
                        }
                        else if (_NGANHANG.KiemTraTonTai(fR.ID, view.FocusedColumn.FieldName, arow))
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên ngân hàng đã tồn tại";
                        }
                        break;
                    case "TenTat":
                        if (arow.ToString().Length < 3 || arow.ToString().Length > 100)
                        {
                            e.Valid = false;
                            e.ErrorText = "Nhập 3-100 kí tự";
                        }
                        else if (_NGANHANG.KiemTraTonTai(fR.ID, view.FocusedColumn.FieldName, arow))
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên tắt ngân hàng đã tồn tại";
                        }
                        break;
                        
                }

                if (fR.ID > 0 && e.Valid)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add(view.FocusedColumn.FieldName, arow);
                    long CapNhatNum = _NGANHANG.CapNhat(dic, fR.ID);
                    if (CapNhatNum < 1)
                    {
                        e.Valid = false;
                        e.ErrorText = "Cập nhật dữ liệu không thành công";
                    }
                }
            }
        }
        #endregion
    }
}