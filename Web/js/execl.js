function ExportToExcel(tableId) //读取表格中每个单元到EXCEL中  
            {
                try {
                    var curTbl = document.getElementById(tableId);
                    var oXL = new ActiveXObject("Excel.Application");
                    //创建AX对象excel  
                    var oWB = oXL.Workbooks.Add();
                    //获取workbook对象  
                    var oSheet = oWB.ActiveSheet;

                    var lenRow = curTbl.rows.length;
                    //取得表格行数  
                    for (i = 0; i < lenRow; i++) {
                        var lenCol = curTbl.rows(i).cells.length;
                        //取得每行的列数  
                        for (j = 0; j < lenCol; j++) {
                            oSheet.Cells(i + 1, j + 1).value = curTbl.rows(i).cells(j).innerText;

                        }
                    }
                    oXL.Visible = true;
                    //设置excel可见属性  
                } catch (e) {
                    if ((! +'\v1')) { //ie浏览器  
                        alert("无法启动Excel，请确保电脑中已经安装了Excel!\n\n如果已经安装了Excel，" + "请调整IE的安全级别。\n\n具体操作：\n\n" + "工具 → Internet选项 → 安全 → 自定义级别 → ActiveX 控件和插件 → 对未标记为可安全执行脚本的ActiveX 控件初始化并执行脚本 → 启用 → 确定");
                    } else {
                        alert("请使用IE浏览器进行“导入到EXCEL”操作！");  //方便设置安全等级，限制为ie浏览器  
                    }
                }
            }

            $(function () {

                //alert('导出的数据越多时间越久！请耐心等待...');
                //ExportToExcel('table123');
                //window.close();

            });