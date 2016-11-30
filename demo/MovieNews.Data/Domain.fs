//namespaces can contain types - not functions

namespace MovieNews.Data


//record type is compiled as C# class with read only properties (and value equality)
type Review = {
        Published : System.DateTime
        Summary : string
        Link : string
        LinkText : string
    }

type MovieBasics = {
        Title : string
        Summary : string
        Thumbnail : option<string>
    }

type Movie = {   
        Movie : MovieBasics 
        Review : option<Review> 
    }

//union type is class hierarchy with tags(?)
//seq<T> -> IEnumerable<T>
//list<T> -> FSharpList<T> -> avoid in public C#
//T1 * T2 -> Tuple<T1, T2> -> probably avoid

