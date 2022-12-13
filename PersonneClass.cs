public class Personne
{
    string mPrenom;
    int mScore;

    public Personne(string Prenom, int Score)
    {
        mPrenom = Prenom;
        mScore = Score;
    }
 
    public string Prenom
    {
        get { return mPrenom; }
        set { mPrenom = value; }
    }
    public int Score
    {
        get { return mScore; }
        set { mScore = value; }
    }
}