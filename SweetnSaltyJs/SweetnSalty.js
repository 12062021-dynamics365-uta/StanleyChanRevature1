var countSweet = 0, countSalty = 0, countSnS = 0;
var concatString = "";
for(let i = 1; i <= 1000; i++) {
    if(i%3 == 0 && i%5 == 0) {
        concatString += "sweet'nSalty "; //add SnS to concatenated string
        countSnS++;
    }
    else if(i%3 == 0) {
        concatString += "sweet "; //add sweet to concatenated string
        countSweet++;
    }
    else if(i%5 == 0){
        concatString += "salty "; //add salty to concatenated string
        countSalty++;
    }
    else
        concatString += i + " "; //add number to concatenated string
    if (i % 20 == 0){   
        console.log(concatString);  //print concatenated string after 20
        concatString = "";          //reset concatenated string for next line of 20
    }
    //concatString += " ";
}
console.log("\nSweet: " + countSweet + "\nSalty: " + countSalty + "\nSweet'nSalty: " + countSnS);
