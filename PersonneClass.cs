public class Personne
{
    string mPrenom;
    int mScore;

    public Personne(string Prenom, int Score)
    {
        mPrenom = Prenom;
        mScore = Score;
    }
 
    public string Prenom // Getter Setter de Prenom
    {
        get { return mPrenom; }
        set { mPrenom = value; }
    }
    public int Score // Getter Setter de Score
    {
        get { return mScore; }
        set { mScore = value; }
    }
}