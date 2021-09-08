
import { Biblioteka } from "./biblioteka.js";
import { Knjiga } from "./knjiga.js";
import { Red } from "./redovi.js";

const kontejner = document.querySelector('.kontejner');

let biblioteka = null

let dodajBtn = document.getElementById('dodaj');
let sacuvajBtn = document.getElementById('sacuvaj');
let ucitajBtn = document.getElementById('ucitaj');

dodajBtn.onclick = () => {


    const naslov = document.getElementById("naslov");
    const autor = document.getElementById("autor");
    const zanr = document.getElementById("zanr");
    const red = document.getElementById("red");

    let knjiga = new Knjiga(naslov.value, autor.value, zanr.value);
    let i = 0;
    while(zanr.value != biblioteka.redovi[i].zanr)
    {
        i++;
    }
    biblioteka.dodajKnjigu(knjiga, i);
}

sacuvajBtn.onclick = () => {
    if(biblioteka == null)
        return;
    let knjige = [];
    let redovi = [];

    biblioteka.redovi.forEach(red => {
        red.knjige.forEach(knjiga => {
            knjige.push({naziv: knjiga.naslov , id: knjiga.id });
        });
        redovi.push({knjige: knjige, zanr: red.zanr,id: red.id});
        knjige = [];
    });
    // biblioteka.sacuvajBiblioteku();
    fetch('https://localhost:5001/Biblioteka/IzmeniBiblioteku', {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
        id: biblioteka.id,
        naziv: biblioteka.ime,
        redovi: redovi
    })
  });


}
ucitajBtn.onclick = () => {
    // biblioteka.ucitajBiblioteku();
    fetch('https://localhost:5001/Biblioteka/PreuzmiBiblioteku')
    .then(res => res.json())
    .then(biblio => {
        let bib = biblio[0];
        console.log(bib);
        let knjige = [];
        let redovi = [];
        makeOptions(bib.redovi);
        bib.redovi.forEach(red => {
            red.knjige.forEach(knjiga => {
                knjige.push(new Knjiga(knjiga.naziv , '', '', knjiga.id));
            });
            // console.log(knjige)
            redovi.push(new Red(knjige,red.zanr,red.id));
            knjige = [];
        });
        biblioteka = new Biblioteka(bib.naziv, redovi, bib.id);
        biblioteka.crtaj(kontejner)
    })
}

function makeOptions(redovi){
    zanr.innerHTML = '';
    redovi.forEach(red => {
        
        let option = document.createElement('option');
        option.value = red.zanr;
        option.innerHTML = red.zanr;
        zanr.appendChild(option)
    })
}
