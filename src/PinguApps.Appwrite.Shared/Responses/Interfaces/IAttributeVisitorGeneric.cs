namespace PinguApps.Appwrite.Shared.Responses.Interfaces;
public interface IAttributeVisitor<T>
{
    T Visit(AttributeBoolean attribute);
    T Visit(AttributeInteger attribute);
    T Visit(AttributeFloat attribute);
    T Visit(AttributeString attribute);
    T Visit(AttributeEmail attribute);
    T Visit(AttributeUrl attribute);
    T Visit(AttributeIp attribute);
    T Visit(AttributeDatetime attribute);
    T Visit(AttributeEnum attribute);
    T Visit(AttributeRelationship attribute);
}
