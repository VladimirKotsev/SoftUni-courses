window.addEventListener("load", solve);

function solve() {
  
  let publishButton = document.getElementById(`publish`);
  publishButton.addEventListener(`click`, (e) => {

    e.preventDefault();
    
    let make = document.getElementById(`make`);
    let model = document.getElementById(`model`);
    let year = document.getElementById(`year`);
    let fuel = document.getElementById(`fuel`);
    let originalCost = document.getElementById(`original-cost`);
    let sellingPrice = document.getElementById(`selling-price`);
    
    if (!make.value || !model.value || !year.value || !fuel.value || !originalCost.value || !sellingPrice.value || originalCost.value >= sellingPrice.value){
      
      return;
    }
    
    let ul = document.getElementById(`cars-list`);
    let tbody = document.getElementById(`table-body`);
    
    
    let tr = document.createElement(`tr`);
    tr.classList.add(`row`);
    
    let tdMake = document.createElement(`td`);
    tdMake.textContent = make.value;
    
    let tdModel = document.createElement(`td`);
    tdModel.textContent = model.value;
    
    let tdYear = document.createElement(`td`);
    tdYear.textContent = year.value;
    
    let tdFuel = document.createElement(`td`);
    tdFuel.textContent = fuel.value;
    
    let tdCost = document.createElement(`td`);
    tdCost.textContent = originalCost.value;
    
    let tdSellPrice = document.createElement(`td`);
    tdSellPrice.textContent = sellingPrice.value;

    make.value = ``;
    model.value = ``;
    year.value = ``;
    fuel.value = ``;
    originalCost.value = ``;
    sellingPrice.value = ``;
    
    tr.appendChild(tdMake);
    tr.appendChild(tdModel);
    tr.appendChild(tdYear);
    tr.appendChild(tdFuel);
    tr.appendChild(tdCost);
    tr.appendChild(tdSellPrice);
    
    let buttonsTd = document.createElement(`td`);
    
    let btnEdit = document.createElement(`button`);
    btnEdit.className = `action-btn edit`;
    btnEdit.textContent = `Edit`;
    btnEdit.addEventListener(`click`, () => {
      
      make.value = tdMake.textContent;
      model.value = tdModel.textContent;
      year.value = tdYear.textContent;
      fuel.value = tdFuel.textContent;
      originalCost.value = tdCost.textContent;
      sellingPrice.value = tdSellPrice.textContent;
      
      tbody.removeChild(tr);
    });

    
    buttonsTd.appendChild(btnEdit);
    
    let btnSell = document.createElement(`button`);
    btnSell.className = `action-btn sell`;
    btnSell.textContent = `Sell`;
    
    btnSell.addEventListener(`click`, () => {
      
      let span1 = document.createElement(`span`);
      span1.textContent = `${tdMake.textContent} ${tdModel.textContent}`;
      
      let span2 = document.createElement(`span`);
      span2.textContent = tdYear.textContent;
      
      let span3 = document.createElement(`span`);
      span3.textContent = tdSellPrice.textContent - tdCost.textContent;

      let li = document.createElement(`li`);
      li.className = `each-list`;
      li.appendChild(span1);
      li.appendChild(span2);
      li.appendChild(span3);
      
      ul.appendChild(li);
      tbody.removeChild(tr);
      
      let profit = document.getElementById(`profit`);
      let sum = Number(profit.textContent);
      sum = Number(sum);
      
      let toAdd = Number(span3.textContent);
      sum += toAdd;

      profit.textContent = sum.toFixed(2);
  
    });
    
    buttonsTd.appendChild(btnSell);
    
    tr.appendChild(buttonsTd);

    tbody.appendChild(tr);
  });
}
