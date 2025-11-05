namespace TextSerializer;

public enum DataType
{
    /// <summary>
    /// Numeric, shoud be left-padded with zeros
    /// </summary>
    N,
    /// <summary>
    /// Textual, should be right-padded with spaces
    /// </summary>
    C,
    /// <summary>
    /// Skip this property
    /// </summary>
    Skip = -1,
}
