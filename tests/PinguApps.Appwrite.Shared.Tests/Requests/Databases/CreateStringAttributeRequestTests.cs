using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateStringAttributeRequestTests : CreateStringAttributeBaseRequestTests<CreateStringAttributeRequest, CreateStringAttributeRequestValidator>
{
    protected override CreateStringAttributeRequest CreateValidCreateStringAttributeBaseRequest => new()
    {
        Size = 100
    };

    protected override string ValidDefaultValue => "A valid string";

    public static TheoryData<CreateStringAttributeRequest> ValidRequests =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 1,
            Encrypt = false
        }
    ];
}
