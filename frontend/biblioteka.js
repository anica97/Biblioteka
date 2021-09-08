import {Red} from './redovi.js';

export class Biblioteka {
    constructor(ime, redovi, id) {
        this.id = id;
        this.redovi = redovi;
        this.ime = ime;
        if (!ime) {
            ime = "Stevan Sindjelic";
        }
        if(!redovi){
            this.redovi = [];
        }
    }

    crtaj(kontejner) {
        kontejner.innerHTML = '';
        let polica = document.createElement("div");
        polica.className = "polica";
        let ime = document.createElement('h2')
        ime.innerHTML=this.ime;
        // for (let index = 0; index < 4; index++) {
        //     let red = new Red(52, '');
        //     red.crtajRed(polica, "nema naslov", 4);
        //     this.redovi.push(red);
        // }
        this.redovi.forEach(red => {
            red.crtajRed(polica, "nema naslov", 4);
        }); 
        kontejner.appendChild(ime);
        kontejner.appendChild(polica);
    }

    dodajKnjigu(knjiga,red){
        if(red <= this.redovi.length){
            this.redovi[red].dodajKnjigu(knjiga);
        }
    }
    sacuvajBiblioteku(){

    }
    ucitajBiblioteku(){

    }
    izbrisiRed(){

    }
    dodajRed(){

    }

}