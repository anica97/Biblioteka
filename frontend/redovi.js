import { Knjiga } from "./knjiga.js";

export class Red {

    constructor(knjige, zanr, id) {
        // this.maxBroj = maxBroj;
        this.id = id;
        this.podRedovi = [];
        this.knjige = knjige;
        this.ref = null;
        this.zanr=zanr;
        // this.pun = false;
        // if (!maxBroj) {
        //     maxBroj = 100;
        // }
        if (!zanr) {
            this.zanr = "svasta";
        }
        if (!knjige) {
            this.knjige = [];
        }  
    }

    crtajRed(kontejner, naslov, brRedova) {

        this.ref = document.createElement("div");
        this.ref.className = "redovi";

        let zanr = document.createElement("p");
        zanr.innerHTML = this.zanr;
        zanr.className = "zanr";

        kontejner.appendChild(this.ref);
        this.ref.appendChild(zanr);

        this.split(4);
        this.knjige.forEach(knjiga => {
            this.crtajKnjigu(knjiga);
        });
    }
    split(brPodRedova){
        for (let index = 0; index < brPodRedova; index++) {
            let podRed=document.createElement("div");
            podRed.className="pod-red";
            this.ref.appendChild(podRed);  
            this.podRedovi.push(podRed)     
        }
    }
    crtajKnjigu(knjiga){
        let i = 0;
        while(this.podRedovi[i].children.length > 4){
            i++;
        }
        knjiga.crtajKnjigu(this.podRedovi[i], this)
    }
    dodajKnjigu(knjiga) {
        let i = 0;
        while(this.podRedovi[i].children.length > 4){
            i++;
        }
        knjiga.crtajKnjigu(this.podRedovi[i], this)
        this.knjige.push(knjiga)
        console.log(this.id)
    }
    
    izbaciKnjigu(knjiga) {
        fetch(`https://localhost:5001/Biblioteka/ObrisiKnjigu/${knjiga.id}`, {
        method: 'DELETE'});

        const index = this.knjige.indexOf(knjiga);
        this.knjige.splice(index, 1);
        knjiga.brisiKnjigu();
        console.log(this.knjige);
    }
}
