#r "../packages/SizSelCsZzz.0.3.36.0/lib/SizSelCsZzz.dll"

type person = { name: string; age: int}

let x = (1,2)


let y, z = x

let x  = <@ fun x -> x % 2 = 0 @> 


//http://fsharpforfunandprofit.com/series/thinking-functionally.html