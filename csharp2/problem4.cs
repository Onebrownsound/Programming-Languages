public interface genericvisitor<T>
{
   T visit(T input);
}

// can be used like such
//public class newvisitor: genericvisitor<meat>, genericvisitor<fruit>, etc. etc.
