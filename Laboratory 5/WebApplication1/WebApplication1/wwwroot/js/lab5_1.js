var n = window.prompt("Podaj liczbę od 5 do 20, określającą ile liczb będzie wylosowanych");

if (isNaN(parseInt(n)) || n < 5 || n > 20) {
    const pElem = document.getElementById("warn-info");
    const pText = document.createTextNode(`Zła opcja: domyślnie wybrano n=10`);
    pElem.appendChild(pText)
    n = 10;
}



var numbers = new Array();
min = Math.ceil(1);
max = Math.floor(99);

for (i = 0; i < n; i++) {
    numbers[i] = Math.floor(Math.random() * (max - min) + min);
}
console.log(numbers);
generateTable();


function generateTable() {
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");

    const firstRow = document.createElement("tr");
    const emptyCell = document.createElement("td");

    emptyCell.classList.add("label")
    firstRow.appendChild(emptyCell);


    for (let i = 0; i < n; i++) {
        const cell = document.createElement("td");
        const text = document.createTextNode(`${numbers[i]}`);

        cell.classList.add("label");

        cell.appendChild(text);
        firstRow.appendChild(cell);
    }
    tblBody.appendChild(firstRow);

    for (let i = 0; i < n; i++) {
        const row = document.createElement("tr");
        const firstCellInRow = document.createElement("td");
        const label = document.createTextNode(`${numbers[i]}`);

        firstCellInRow.classList.add('label');

        firstCellInRow.appendChild(label);
        row.appendChild(firstCellInRow)

        for (let j = 0; j < n; j++) {
            let cell = document.createElement("td");
            let value = numbers[i] * numbers[j];
            let text = document.createTextNode(`${value}`);

            if (value % 2 === 0) {
                cell.classList.add('even');
            }
            else {
                cell.classList.add('odd')
            }
            cell.appendChild(text);
            row.appendChild(cell);
        }
        tblBody.appendChild(row);
    }


    tbl.appendChild(tblBody);
    document.body.appendChild(tbl);

    tbl.setAttribute("border", "2");
}


lorem


