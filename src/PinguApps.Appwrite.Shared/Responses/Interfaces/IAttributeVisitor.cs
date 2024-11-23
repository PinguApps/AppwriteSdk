namespace PinguApps.Appwrite.Shared.Responses.Interfaces;
public interface IAttributeVisitor
{
    void Visit(AttributeBoolean attribute);
    void Visit(AttributeInteger attribute);
    void Visit(AttributeFloat attribute);
    void Visit(AttributeString attribute);
    void Visit(AttributeEmail attribute);
    void Visit(AttributeUrl attribute);
    void Visit(AttributeIp attribute);
    void Visit(AttributeDatetime attribute);
    void Visit(AttributeEnum attribute);
    void Visit(AttributeRelationship attribute);
}
