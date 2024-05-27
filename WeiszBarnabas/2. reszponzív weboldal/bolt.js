const bicajok = ["1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg", "7.jpg", "8.jpg", "9.jpg"];
const arak = [9649, 9499, 8600, 8000, 7400, 7200, 7100, 6999, 6499];
let i;
const arazo = document.getElementById("ar");

const selectBike = () => {
  arazo.innerText = "Az ára: ?"
  const valaszto = document.getElementById("mySelect");
  i = valaszto.selectedIndex;
  document.getElementById("selectedBike").innerHTML = `<img src="kepek/Bicajok/${bicajok[i - 1]}" alt="mybike" class="img-fluid">`;
};

const megveszem = () => {
    arazo.innerText = `Az ára: ${arak[i-1]} $`
};
