namespace Application.Queries.Common.Models.ViewModels;

[Serializable]
public class SignatureSettingViewModal
{
    public List<string> SignatureAppearances { set; get; }
    public DigitalSignatureViaServerKeyViewModal DigitalSignatureViaServerKeys { set; get; }
    public DigitalSignatureViaLocalKeyViewModal DigitalSignatureViaLocalKeys { set; get; }
}

[Serializable]
public class DigitalSignatureViaServerKeyViewModal
{
    public List<SigningServerViewModal> SigningServers { get; set; }
}

[Serializable]
public class DigitalSignatureViaLocalKeyViewModal
{
    public List<NameAndIdViewModal> SigningServers { get; set; }
}

[Serializable]
public class SigningServerViewModal
{
    public NameAndIdViewModal SigningProfile { get; set; }
    public SignatureViewModal ElectronicSeal { get; set; }
    public SignatureViewModal AdvancedElectronicSeal { get; set; }
    public SignatureViewModal QualifiedElectronicSeal { get; set; }
    public SignatureViewModal AdvanceElectronicSignature { get; set; }
    public SignatureViewModal HighTrustAdvanced { get; set; }
    public SignatureViewModal QualifiedElectronicSignature { get; set; }
    public CSPViewModal CSP { get; set; }
}

[Serializable]
public class NameAndIdViewModal
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[Serializable]
public class SignatureViewModal
{
    public bool Enabled { get; set; }
    public List<NameAndIdViewModal> CertificationProfiles { get; set; }
}

[Serializable]
public class CSPViewModal
{
    public bool Enabled { get; set; }
    public NameAndIdViewModal RegistrationProfile { get; set; }
    public bool AutoUserDeletionEnabled { get; set; }
}