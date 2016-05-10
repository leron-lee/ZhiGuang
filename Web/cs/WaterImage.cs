using System;
public class WaterImage
{
    private string m_sourcePicture;
    private string m_waterImager;
    private float m_alpha;
    private ImagePosition m_postition;
    private string m_words;
    public string SourcePicture
    {
        get
        {
            return this.m_sourcePicture;
        }
        set
        {
            this.m_sourcePicture = value;
        }
    }
    public string WaterPicture
    {
        get
        {
            return this.m_waterImager;
        }
        set
        {
            this.m_waterImager = value;
        }
    }
    public float Alpha
    {
        get
        {
            return this.m_alpha;
        }
        set
        {
            this.m_alpha = value;
        }
    }
    public ImagePosition Position
    {
        get
        {
            return this.m_postition;
        }
        set
        {
            this.m_postition = value;
        }
    }
    public string Words
    {
        get
        {
            return this.m_words;
        }
        set
        {
            this.m_words = value;
        }
    }
}
