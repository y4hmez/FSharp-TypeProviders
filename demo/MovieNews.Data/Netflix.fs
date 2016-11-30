
//modules are compiled as static class
module MovieNews.Data.Netflix
open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

// let m2 = regexThumb.Match("""<a href="https://dvd.netflix.com/Movie/The-Revenant/80064516"><img src="//secure.netflix.com/us/boxshots/small/80064516.jpg"/></a><br>Set in the 1820s American frontier, this snowy thriller follows fu
// r trapper Hugh Glass as he relentlessly seeks retribution against the companions who left him for dead in the Missouri River's icy waters after he was mauled by a bear."
// >""")

// m2.Groups.[2].Value

type Netflix = XmlProvider<"http://dvd.netflix.com/Top100RSS">

let getTop100() =
    let top = Netflix.GetSample()
    [ for it in top.Channel.Items -> 
        let m = regexThumb.Match(it.Description)
        let descr, thumb = 
            if m.Success then
               m.Groups.[2].Value,
               Some(m.Groups.[1].Value)
            else it.Description, None
        {   Title = it.Title
            Summary = descr
            Thumbnail = thumb } ]
