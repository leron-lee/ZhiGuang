using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
public class Code128
{
    public enum Encode
    {
        Code128A,
        Code128B,
        Code128C,
        EAN128
    }
    private HttpContext context = HttpContext.Current;
    private DataTable m_Code128 = new DataTable();
    private uint m_Height = 45u;
    private System.Drawing.Font m_ValueFont = null;
    private byte m_Magnify = 0;
    public uint Height
    {
        get
        {
            return this.m_Height;
        }
        set
        {
            this.m_Height = value;
        }
    }
    public System.Drawing.Font ValueFont
    {
        get
        {
            return this.m_ValueFont;
        }
        set
        {
            this.m_ValueFont = value;
        }
    }
    public byte Magnify
    {
        get
        {
            return this.m_Magnify;
        }
        set
        {
            this.m_Magnify = value;
        }
    }
    public string getimg(object p_Text)
    {
        string fig = "";
        if (p_Text.ToString() != "")
        {
            System.Drawing.Bitmap b = new Code128().GetCodeImage(p_Text.ToString(), Code128.Encode.Code128C);
            fig = "/file/" + p_Text + ".jpg";
            b.Save(this.context.Server.MapPath(fig), System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        return fig;
    }
    public Code128()
    {
        this.m_Code128.Columns.Add("ID");
        this.m_Code128.Columns.Add("Code128A");
        this.m_Code128.Columns.Add("Code128B");
        this.m_Code128.Columns.Add("Code128C");
        this.m_Code128.Columns.Add("BandCode");
        this.m_Code128.CaseSensitive = true;
        this.m_Code128.Rows.Add(new object[]
		{
			"0",
			" ",
			" ",
			"00",
			"212222"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"1",
			"!",
			"!",
			"01",
			"222122"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"2",
			"\"",
			"\"",
			"02",
			"222221"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"3",
			"#",
			"#",
			"03",
			"121223"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"4",
			"$",
			"$",
			"04",
			"121322"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"5",
			"%",
			"%",
			"05",
			"131222"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"6",
			"&",
			"&",
			"06",
			"122213"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"7",
			"'",
			"'",
			"07",
			"122312"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"8",
			"(",
			"(",
			"08",
			"132212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"9",
			")",
			")",
			"09",
			"221213"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"10",
			"*",
			"*",
			"10",
			"221312"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"11",
			"+",
			"+",
			"11",
			"231212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"12",
			",",
			",",
			"12",
			"112232"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"13",
			"-",
			"-",
			"13",
			"122132"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"14",
			".",
			".",
			"14",
			"122231"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"15",
			"/",
			"/",
			"15",
			"113222"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"16",
			"0",
			"0",
			"16",
			"123122"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"17",
			"1",
			"1",
			"17",
			"123221"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"18",
			"2",
			"2",
			"18",
			"223211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"19",
			"3",
			"3",
			"19",
			"221132"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"20",
			"4",
			"4",
			"20",
			"221231"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"21",
			"5",
			"5",
			"21",
			"213212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"22",
			"6",
			"6",
			"22",
			"223112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"23",
			"7",
			"7",
			"23",
			"312131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"24",
			"8",
			"8",
			"24",
			"311222"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"25",
			"9",
			"9",
			"25",
			"321122"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"26",
			":",
			":",
			"26",
			"321221"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"27",
			";",
			";",
			"27",
			"312212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"28",
			"<",
			"<",
			"28",
			"322112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"29",
			"=",
			"=",
			"29",
			"322211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"30",
			">",
			">",
			"30",
			"212123"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"31",
			"?",
			"?",
			"31",
			"212321"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"32",
			"@",
			"@",
			"32",
			"232121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"33",
			"A",
			"A",
			"33",
			"111323"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"34",
			"B",
			"B",
			"34",
			"131123"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"35",
			"C",
			"C",
			"35",
			"131321"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"36",
			"D",
			"D",
			"36",
			"112313"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"37",
			"E",
			"E",
			"37",
			"132113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"38",
			"F",
			"F",
			"38",
			"132311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"39",
			"G",
			"G",
			"39",
			"211313"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"40",
			"H",
			"H",
			"40",
			"231113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"41",
			"I",
			"I",
			"41",
			"231311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"42",
			"J",
			"J",
			"42",
			"112133"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"43",
			"K",
			"K",
			"43",
			"112331"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"44",
			"L",
			"L",
			"44",
			"132131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"45",
			"M",
			"M",
			"45",
			"113123"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"46",
			"N",
			"N",
			"46",
			"113321"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"47",
			"O",
			"O",
			"47",
			"133121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"48",
			"P",
			"P",
			"48",
			"313121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"49",
			"Q",
			"Q",
			"49",
			"211331"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"50",
			"R",
			"R",
			"50",
			"231131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"51",
			"S",
			"S",
			"51",
			"213113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"52",
			"T",
			"T",
			"52",
			"213311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"53",
			"U",
			"U",
			"53",
			"213131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"54",
			"V",
			"V",
			"54",
			"311123"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"55",
			"W",
			"W",
			"55",
			"311321"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"56",
			"X",
			"X",
			"56",
			"331121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"57",
			"Y",
			"Y",
			"57",
			"312113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"58",
			"Z",
			"Z",
			"58",
			"312311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"59",
			"[",
			"[",
			"59",
			"332111"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"60",
			"\\",
			"\\",
			"60",
			"314111"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"61",
			"]",
			"]",
			"61",
			"221411"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"62",
			"^",
			"^",
			"62",
			"431111"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"63",
			"_",
			"_",
			"63",
			"111224"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"64",
			"NUL",
			"`",
			"64",
			"111422"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"65",
			"SOH",
			"a",
			"65",
			"121124"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"66",
			"STX",
			"b",
			"66",
			"121421"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"67",
			"ETX",
			"c",
			"67",
			"141122"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"68",
			"EOT",
			"d",
			"68",
			"141221"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"69",
			"ENQ",
			"e",
			"69",
			"112214"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"70",
			"ACK",
			"f",
			"70",
			"112412"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"71",
			"BEL",
			"g",
			"71",
			"122114"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"72",
			"BS",
			"h",
			"72",
			"122411"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"73",
			"HT",
			"i",
			"73",
			"142112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"74",
			"LF",
			"j",
			"74",
			"142211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"75",
			"VT",
			"k",
			"75",
			"241211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"76",
			"FF",
			"I",
			"76",
			"221114"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"77",
			"CR",
			"m",
			"77",
			"413111"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"78",
			"SO",
			"n",
			"78",
			"241112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"79",
			"SI",
			"o",
			"79",
			"134111"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"80",
			"DLE",
			"p",
			"80",
			"111242"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"81",
			"DC1",
			"q",
			"81",
			"121142"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"82",
			"DC2",
			"r",
			"82",
			"121241"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"83",
			"DC3",
			"s",
			"83",
			"114212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"84",
			"DC4",
			"t",
			"84",
			"124112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"85",
			"NAK",
			"u",
			"85",
			"124211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"86",
			"SYN",
			"v",
			"86",
			"411212"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"87",
			"ETB",
			"w",
			"87",
			"421112"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"88",
			"CAN",
			"x",
			"88",
			"421211"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"89",
			"EM",
			"y",
			"89",
			"212141"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"90",
			"SUB",
			"z",
			"90",
			"214121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"91",
			"ESC",
			"{",
			"91",
			"412121"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"92",
			"FS",
			"|",
			"92",
			"111143"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"93",
			"GS",
			"}",
			"93",
			"111341"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"94",
			"RS",
			"~",
			"94",
			"131141"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"95",
			"US",
			"DEL",
			"95",
			"114113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"96",
			"FNC3",
			"FNC3",
			"96",
			"114311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"97",
			"FNC2",
			"FNC2",
			"97",
			"411113"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"98",
			"SHIFT",
			"SHIFT",
			"98",
			"411311"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"99",
			"CODEC",
			"CODEC",
			"99",
			"113141"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"100",
			"CODEB",
			"FNC4",
			"CODEB",
			"114131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"101",
			"FNC4",
			"CODEA",
			"CODEA",
			"311141"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"102",
			"FNC1",
			"FNC1",
			"FNC1",
			"411131"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"103",
			"StartA",
			"StartA",
			"StartA",
			"211412"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"104",
			"StartB",
			"StartB",
			"StartB",
			"211214"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"105",
			"StartC",
			"StartC",
			"StartC",
			"211232"
		});
        this.m_Code128.Rows.Add(new object[]
		{
			"106",
			"Stop",
			"Stop",
			"Stop",
			"2331112"
		});
    }
    public System.Drawing.Bitmap GetCodeImage(string p_Text, Code128.Encode p_Code)
    {
        string _ViewText = p_Text;
        string _Text = "";
        System.Collections.Generic.IList<int> _TextNumb = new System.Collections.Generic.List<int>();
        int _Examine = 0;
        switch (p_Code)
        {
            case Code128.Encode.Code128C:
                _Examine = 105;
                if ((p_Text.Length & 1) != 0)
                {
                    throw new System.Exception("128C长度必须是偶数");
                }
                while (p_Text.Length != 0)
                {
                    int _Temp = 0;
                    try
                    {
                        int _CodeNumb128 = int.Parse(p_Text.Substring(0, 2));
                    }
                    catch
                    {
                        throw new System.Exception("128C必须是数字！");
                    }
                    _Text += this.GetValue(p_Code, p_Text.Substring(0, 2), ref _Temp);
                    _TextNumb.Add(_Temp);
                    p_Text = p_Text.Remove(0, 2);
                }
                break;
            case Code128.Encode.EAN128:
                _Examine = 105;
                if ((p_Text.Length & 1) != 0)
                {
                    throw new System.Exception("EAN128长度必须是偶数");
                }
                _TextNumb.Add(102);
                _Text += "411131";
                while (p_Text.Length != 0)
                {
                    int _Temp = 0;
                    try
                    {
                        int _CodeNumb128 = int.Parse(p_Text.Substring(0, 2));
                    }
                    catch
                    {
                        throw new System.Exception("128C必须是数字！");
                    }
                    _Text += this.GetValue(Code128.Encode.Code128C, p_Text.Substring(0, 2), ref _Temp);
                    _TextNumb.Add(_Temp);
                    p_Text = p_Text.Remove(0, 2);
                }
                break;
            default:
                if (p_Code == Code128.Encode.Code128A)
                {
                    _Examine = 103;
                }
                else
                {
                    _Examine = 104;
                }
                while (p_Text.Length != 0)
                {
                    int _Temp = 0;
                    string _ValueCode = this.GetValue(p_Code, p_Text.Substring(0, 1), ref _Temp);
                    if (_ValueCode.Length == 0)
                    {
                        throw new System.Exception("无效的字符集!" + p_Text.Substring(0, 1).ToString());
                    }
                    _Text += _ValueCode;
                    _TextNumb.Add(_Temp);
                    p_Text = p_Text.Remove(0, 1);
                }
                break;
        }
        if (_TextNumb.Count == 0)
        {
            throw new System.Exception("错误的编码,无数据");
        }
        _Text = _Text.Insert(0, this.GetValue(_Examine));
        for (int i = 0; i != _TextNumb.Count; i++)
        {
            _Examine += _TextNumb[i] * (i + 1);
        }
        _Examine %= 103;
        _Text += this.GetValue(_Examine);
        _Text += "2331112";
        System.Drawing.Bitmap _CodeImage = this.GetImage(_Text);
        this.GetViewText(_CodeImage, _ViewText);
        return _CodeImage;
    }
    private string GetValue(Code128.Encode p_Code, string p_Value, ref int p_SetID)
    {
        string result;
        if (this.m_Code128 == null)
        {
            result = "";
        }
        else
        {
            DataRow[] _Row = this.m_Code128.Select(p_Code.ToString() + "='" + p_Value + "'");
            if (_Row.Length != 1)
            {
                throw new System.Exception("错误的编码" + p_Value.ToString());
            }
            p_SetID = int.Parse(_Row[0]["ID"].ToString());
            result = _Row[0]["BandCode"].ToString();
        }
        return result;
    }
    private string GetValue(int p_CodeId)
    {
        DataRow[] _Row = this.m_Code128.Select("ID='" + p_CodeId.ToString() + "'");
        if (_Row.Length != 1)
        {
            throw new System.Exception("验效位的编码错误" + p_CodeId.ToString());
        }
        return _Row[0]["BandCode"].ToString();
    }
    private System.Drawing.Bitmap GetImage(string p_Text)
    {
        char[] _Value = p_Text.ToCharArray();
        int _Width = 0;
        for (int i = 0; i != _Value.Length; i++)
        {
            _Width += int.Parse(_Value[i].ToString()) * (int)(this.m_Magnify + 1);
        }
        System.Drawing.Bitmap _CodeImage = new System.Drawing.Bitmap(_Width, (int)this.m_Height);
        System.Drawing.Graphics _Garphics = System.Drawing.Graphics.FromImage(_CodeImage);
        int _LenEx = 0;
        for (int i = 0; i != _Value.Length; i++)
        {
            int _ValueNumb = int.Parse(_Value[i].ToString()) * (int)(this.m_Magnify + 1);
            if ((i & 1) != 0)
            {
                _Garphics.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(_LenEx, 0, _ValueNumb, (int)this.m_Height));
            }
            else
            {
                _Garphics.FillRectangle(System.Drawing.Brushes.Black, new System.Drawing.Rectangle(_LenEx, 0, _ValueNumb, (int)this.m_Height));
            }
            _LenEx += _ValueNumb;
        }
        _Garphics.Dispose();
        return _CodeImage;
    }
    private void GetViewText(System.Drawing.Bitmap p_Bitmap, string p_ViewText)
    {
        if (this.m_ValueFont != null)
        {
            System.Drawing.Graphics _Graphics = System.Drawing.Graphics.FromImage(p_Bitmap);
            System.Drawing.SizeF _DrawSize = _Graphics.MeasureString(p_ViewText, this.m_ValueFont);
            if (_DrawSize.Height > (float)(p_Bitmap.Height - 10) || _DrawSize.Width > (float)p_Bitmap.Width)
            {
                _Graphics.Dispose();
            }
            else
            {
                int _StarY = p_Bitmap.Height - (int)_DrawSize.Height;
                _Graphics.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(0, _StarY, p_Bitmap.Width, (int)_DrawSize.Height));
                _Graphics.DrawString(p_ViewText, this.m_ValueFont, System.Drawing.Brushes.Black, 0f, (float)_StarY);
            }
        }
    }
    internal System.Drawing.Image GetCodeImage(string p)
    {
        throw new System.NotImplementedException();
    }
}
