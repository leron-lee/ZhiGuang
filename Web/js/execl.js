function ExportToExcel(tableId) //��ȡ�����ÿ����Ԫ��EXCEL��  
            {
                try {
                    var curTbl = document.getElementById(tableId);
                    var oXL = new ActiveXObject("Excel.Application");
                    //����AX����excel  
                    var oWB = oXL.Workbooks.Add();
                    //��ȡworkbook����  
                    var oSheet = oWB.ActiveSheet;

                    var lenRow = curTbl.rows.length;
                    //ȡ�ñ������  
                    for (i = 0; i < lenRow; i++) {
                        var lenCol = curTbl.rows(i).cells.length;
                        //ȡ��ÿ�е�����  
                        for (j = 0; j < lenCol; j++) {
                            oSheet.Cells(i + 1, j + 1).value = curTbl.rows(i).cells(j).innerText;

                        }
                    }
                    oXL.Visible = true;
                    //����excel�ɼ�����  
                } catch (e) {
                    if ((! +'\v1')) { //ie�����  
                        alert("�޷�����Excel����ȷ���������Ѿ���װ��Excel!\n\n����Ѿ���װ��Excel��" + "�����IE�İ�ȫ����\n\n���������\n\n" + "���� �� Internetѡ�� �� ��ȫ �� �Զ��弶�� �� ActiveX �ؼ��Ͳ�� �� ��δ���Ϊ�ɰ�ȫִ�нű���ActiveX �ؼ���ʼ����ִ�нű� �� ���� �� ȷ��");
                    } else {
                        alert("��ʹ��IE��������С����뵽EXCEL��������");  //�������ð�ȫ�ȼ�������Ϊie�����  
                    }
                }
            }

            $(function () {

                //alert('����������Խ��ʱ��Խ�ã������ĵȴ�...');
                //ExportToExcel('table123');
                //window.close();

            });