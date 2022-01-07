//-- “Please enter a starting number” 
//-- “Please enter a final number” 
//-- “Please press enter”                    
//- The start and stop numbers must be validated to be at least 200 apart and no more than 10,000 apart.
//- You also will implement input validation to verify that only positive numbers are entered and that the start number is less than the stop number. 
//- You will have small, red text that pops up under the input box to explain what the user did wrong while presenting that step again.  
//- There will be 40 numbers on each line, except the last line. 
//- The numbers printed to the web page will be formatted correctly (with commas like => 12,453) 
//- Every “sweet”, “salty”, and “sweetnsalty” printed must have a green background with white text.

//- Start with a screen that explains the game and how the user will input their choices.   
//- Each step is visible only after the previous step has been successfully completed. 
//- Present a start button.  
//-- Step 1: The user enters the number to start with. Then clicks Enter.  
//-- Step 2: The user enters the number to finish with. Then clicks Enter.  
//-- Step 4: Print sweet, salty, sweet'nSalty, and the numbers to the screen as the user instructed.  
//-- Step 5: Print the total number of sweet, salty, and sweet’nSalty after printing the numbers and words. 
//-- Step 6: After all the numbers have been printed, present a button allowing the user to delete everything and restart.

//create start button
let startButton = document.createElement('button');
//add to body
document.body.appendChild(startButton);
startButton.innerText = 'Start da ting';

//global boolean
let goodValues = false;

//global delete button
let deleteStuff = document.createElement('button');
deleteStuff.innerText = 'Press to delete stuff';

//validation functions
function validateNums() {
    //splain the rules
    let rules = document.createElement('p');
    document.body.append(rules);
    rules.innerText = "Enter a starting number and final number where the difference is between 200 and 10,000 inclusive."
    +"\n Numbers must be positive. \nEvery multiple of 3 will print 'sweet', Every multiple of 5 will print 'salty',"
    +"\nEvery multiple of 15 will print 'sweetn'Salty'.";

    linebreak = document.createElement("br");
    document.body.appendChild(linebreak);

    //start inputfield and button
    let startNum = document.createElement('input');
    document.body.appendChild(startNum);
    let submitStartNum = document.createElement('button');
    document.body.appendChild(submitStartNum);
    submitStartNum.innerText = 'Enter';

    linebreak = document.createElement("br");
    document.body.appendChild(linebreak);

    //final inputfield and button
    let finalNum = document.createElement('input');
    document.body.appendChild(finalNum);
    let submitFinalNum = document.createElement('button');
    document.body.appendChild(submitFinalNum);
    submitFinalNum.innerText = 'Enter';

    linebreak = document.createElement("br");
    document.body.appendChild(linebreak);

    //startNum click
    submitStartNum.addEventListener('click', (e) => {
        let startValue = startNum.value;
        let finalValue = finalNum.value;
        console.log(startValue);
        console.log(finalValue);
        goodValues = check(finalValue, startValue);
        console.log(goodValues);
        if(goodValues)
        {
            document.body.removeChild(errorMsg);
            printStuff(startValue, finalValue);
            document.body.appendChild(deleteStuff); //delete button shows itself
        }
    });

    //finalNum Click
    submitFinalNum.addEventListener('click', (e) => {
        let startValue = startNum.value;
        let finalValue = finalNum.value;
        console.log(startValue);
        console.log(finalValue);
        goodValues = check(finalValue, startValue);
        console.log(goodValues);
        if(goodValues)
        {
            document.body.removeChild(errorMsg);
            printStuff(startValue, finalValue);
            document.body.appendChild(deleteStuff); //delete button shows itself
        }
    });

    //error message under input
    let errorMsg = document.createElement('p');
    document.body.appendChild(errorMsg);

    function check(finalValue, startValue){
        if(startValue < 0 || finalValue < 0){
            errorMsg.innerHTML = "<span style = 'color:red; font-size:small'>Numbers not positive.</span>";
            return false;
        }
        if(startValue > finalValue){
            errorMsg.innerHTML = "<span style = 'color:red; font-size:small'>Final number is less than starting number.</span>";
            return false;
        }
        if (finalValue-startValue < 200 || finalValue-startValue > 10000) {
            errorMsg.innerHTML = "<span style = 'color:red; font-size:small'>Not at least 200 apart or Over 10000 apart.</span>";
            return false;
        }
        return true;
    //separate out if statements to print out different error messages; only positive, start less than stop
    }
  }
  

function printStuff(startNum, finalNum){
    let concatString = new Array();
    //let arrayIndex = 0; IDK why, trying to use arrayIndex didnt allow the numbers to be added to the array
    let countSweet = 0, countSalty = 0, countSnS = 0;
    
    for(let i = startNum; i <= finalNum; i++)
    {
        
        if(i%3 == 0 && i%5 == 0) {
            concatString.push("<span style = 'color:white; background:green'>sweet\'nSalty </span>"); //add SnS to concatenated string
            countSnS++;
            //arrayIndex++;
        }
        else if(i%3 == 0) {
            concatString.push("<span style = 'color:white; background:green'>sweet </span>"); //add sweet to concatenated string
            countSweet++;
            //arrayIndex++;
        }
        else if(i%5 == 0){
            concatString.push("<span style = 'color:white; background:green'>salty </span>"); //add salty to concatenated string
            countSalty++;
            //arrayIndex++;
        }
        else{
            concatString.push(`<span>${i.toString()} </span>`); //add number to concatenated string *******(How do I format to 12,345?)
            //console.log("check num going in " + i);
        }
        if (i % 40 == 0){
            let tempIn = document.createElement('p');
            tempIn.innerHTML = concatString;  //print concatenated string after 40
            document.body.appendChild(tempIn);
            concatString = [];          //reset concatenated string for next line of 40
            //arrayIndex = 0;
        }
        //concatString[arrayIndex] += " ";
    }

    //print out last concatString when remainder under 40
    let tempIn = document.createElement('p');
    tempIn.innerHTML = concatString;
    document.body.appendChild(tempIn);
    
    //print out the Counts
    let printAll = document.createElement('p');
    document.body.appendChild(printAll);
    printAll.innerText = "\nSweet: " + countSweet + "\nSalty: " + countSalty + "\nSweet'nSalty: " + countSnS;

}

// on click
startButton.addEventListener('click', (e) => {
  alert("Enter a starting number and final number where the difference is between 200 and 10,000 inclusive."
        +"\n Numbers must be positive. Every multiple of 3 will print 'sweet', Every multiple of 5 will print 'salty',"
        +"Every multiple of 15 will print 'sweetn'Salty'.");
  document.body.removeChild(startButton);
  validateNums();
 });

 deleteStuff.addEventListener('click', (e) => {
    window.location.reload();
});