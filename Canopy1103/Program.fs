//these are similar to C# using statements
open canopy
open runner
open System
open System.Net
open OpenQA.Selenium

//start an instance of the firefox browser
start firefox

let checkImage (imageElement : IWebElement) =
    let imgUrl = imageElement.GetAttribute "src"
    let request = WebRequest.Create imgUrl
    try
        request.GetResponse() |> ignore
        Some(imgUrl)
    with
        | _ -> None
    
    
 
//this is how you define a test
"taking canopy for a spin" &&& fun _ ->
    //this is an F# function body, it's whitespace enforced

      url  "http://practiceguideslocal.chambersandpartners.com/country/228"

      let header = element ".navbar-brand>img"

      let img = element ".guide-image"


      match (checkImage header) with
      | Some(x) -> printf "found %A" x
      | None -> failwith "BrokenImage!"

      match (checkImage img) with
      | Some(x) -> printf "found %A" x
      | None -> failwith "BrokenImage!"
      

      let names = element ".btn-square" |> elementsWithin "span"

      printf "%A" (names.[0].Text = "Compare")

      //names == "Compare"

      
      
       //highlight ".guide-name"

      ".guide-name" == "Life Sciences 2013-2014" 

      click ".btn-square" 

      js "alert('dummy click');"

      sleep 2 


//    //go to url
//    url "http://lefthandedgoat.github.io/canopy/testpages/"
//
//    //assert that the element with an id of 'welcome' has
//    //the text 'Welcome'
//    "#welcome" == "Welcome"
//
//    //assert that the element with an id of 'firstName' has the value 'John'
//    "#firstName" == "John"
//
//    //change the value of element with
//    //an id of 'firstName' to 'Something Else'
//    "#firstName" << "Something Else"
//
//    //verify another element's value, click a button,
//    //verify the element is updated
//    "#button_clicked" == "button not clicked"
//    click "#button"
//    "#button_clicked" == "button clicked"

//run all tests
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()