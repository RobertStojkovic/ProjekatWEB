import {Porudzbina} from "./porudzbina.js";

export class Sto{

    constructor(rbr,stanje,maxKapacitet,ime,prezime){
        this.rbr=rbr; //redni broj stola
        this.stanje=stanje; // da li sto zauzet ili nije
        this.maxKapacitet=maxKapacitet; // maksimalan broj ljudi za stolom
        this.kapacitet=0; //koliko ima ljudi za stolom
        this.ime=ime;
        this.prezime=prezime;
        this.stoKontejner=null;


    }


    vratiStanje(){
        if(this.stanje==="slobodan")
            return "rgb(255,255,255)";
        else
            return "rgb(255, 0, 0)";

    }

    crtajSto(host){
        if(!host)
           throw new Exception ("Roditeljski element ne postoji!");
        this.stoKontejner=document.createElement("div");
        this.stoKontejner.className="stoKontejner";
        this.stoKontejner.innerHTML=this.rbr + "\n" +"\n slobodan";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();
        host.appendChild(this.stoKontejner);

    }

    crtajSto1(host){
        if(!host)
           throw new Exception ("Roditeljski element ne postoji!");
        this.stoKontejner=document.createElement("div");
        this.stoKontejner.className="stoKontejner";
        this.stoKontejner.innerHTML= this.rbr + "\n" +"\n zauzet";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();
        host.appendChild(this.stoKontejner);

    }

    zauzmiSto(brojStola, brojLjudi){
        if(this.stanje==="zauzet" || this.maxKapacitet<=brojLjudi)
            alert("Sto je vec rezervisan!");
        else{
            this.rbr=brojStola;
            this.kapacitet=brojLjudi;
            this.stanje="zauzet";
            this.stoKontejner.innerHTML= "Sto:" + this.rbr +"\n je" + "\t zauzet";
            this.stoKontejner.style.backgroundColor=this.vratiStanje(); 
        }
    }


    oslobodiSto(rbr){
        this.stanje="slobodan";
        this.kapacitet=0;
        this.stoKontejner.innerHTML=rbr + "\n" +"\n slobodan";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();

    }

    izmeniSto(rbr, br, ime, prezime){
        this.rbr=rbr;
        this.kapacitet +=parseInt(br);
        this.ime=ime;
        this.prezime=prezime;
        this.stoKontejner.innerHTML= "Sto :" +  this.rbr +"\n je" + "\t zauzet";


    }


    naruciSaStola(rbr,nar){
        if(this.stanje=="slobodan")
           alert("Sa ovog stola je nemoguce  naru??iti jer je sto slobodan!");
        else{
            let naruciDugme=document.createElement("button");
            naruciDugme.className="naruciDugme";
            naruciDugme.innerHTML="Naru??eno";
            this.stoKontejner.appendChild(naruciDugme);
            naruciDugme.onclick=(ev)=>{
                alert("Broj narud??bine je:"+ nar.getID()+ "\n Naru??en je desert :"+ nar.getDesert()+ "\n Naru??eno je pi??e:"+ nar.getPice());
            }
        }   
    }

    kliknuto(rbr, i, p)
    {
        this.stoKontejner.addEventListener("click", () => {
            confirm("Sto broj" + rbr + " "+ "je zauzeo/la"+ " "+ i + " "+ p);
        });

    }

}