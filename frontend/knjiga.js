
export class Knjiga {
    constructor(naslov, autor, zanr, id) {
        this.id = id;
        this.naslov = naslov;
        this.autor = autor;
        this.zanr = zanr;
        this.ref = null;
        if (!naslov) {
            this.naslov = "knjiga";
        }
        if (!autor) {
            this.autor = "Narodno";
        }
        if (!zanr) {
            this.zanr = "svasta";
        }
    }

    crtajKnjigu(kontejner, brisiHandler) {
        let knjiga = document.createElement("div");
        knjiga.className = "knjiga";

        knjiga.onclick = () => brisiHandler.izbaciKnjigu(this);

        let visina = document.createElement("div");
        visina.className = "visina";

        let ostalo = document.createElement("div");
        ostalo.className = "ostalo";
        ostalo.style.flexGrow = Math.random() * 2.5
        let p = document.createElement("p");
        p.innerHTML =  this.naslov.slice(0, 9);

        visina.appendChild(p);
        knjiga.appendChild(ostalo);
        knjiga.appendChild(visina);
        kontejner.appendChild(knjiga);

        this.ref = knjiga;

    }
    brisiKnjigu(){
        this.ref.parentElement.removeChild(this.ref);
    }

}



// fetch('https://localhost:5001/Biblioteka/UpisiBiblioteku', {
//     method: 'POST',
//     headers: {
//       'Accept': 'application/json',
//       'Content-Type': 'application/json'
//     },
//     body: JSON.stringify({
//         naziv: "Aleksandrova",
//         redovi: [
//         {
//             Zanr: "Komedija",
//             knjige: [
//                 {naziv: "Rat i mir"},
//                 {naziv: "RGuliverova putovanja"}
//             ]
//         },
//         {
//             Zanr: "Istorija",
//             knjige: [
//                 {naziv: "Balkanski ratovi"},
//                 {naziv: "Sloveni"}
//             ]
//         },
//         {
//             Zanr: "Fantastika",
//             knjige: [
//                 {naziv: "Gospodar prstenova"},
//                 {naziv: "Harry potter"}
//             ]
//         },
//         {
//             Zanr: "Duh i telo",
//             knjige: [
//                 {naziv: "Bozanski matrix"},
//                 {naziv: "Luiza hej"}
//             ]
//         } 
//         ]
//     })
//   });