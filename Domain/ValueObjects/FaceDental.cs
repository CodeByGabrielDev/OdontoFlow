namespace Domain.ValueObjects;

public class FaceDental
{
    public string Face{get;private set;}
    public string Status{get;private set;}

    private FaceDental(){ }

    public FaceDental(string face,string status)
    {
         if (string.IsNullOrWhiteSpace(face))
            throw new ArgumentException("Face não pode ser vazia.");

        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Status não pode ser vazio.");

        this.Face = face;
        this.Status = status;
    }
}