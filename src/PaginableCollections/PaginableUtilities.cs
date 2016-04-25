public static class Paginable
{
    public static IPaginable<T> EmptyPaginable<T>()
    {
        return Enumerable.Empty<T>().ToPaginable(1, 1);
    }
}
