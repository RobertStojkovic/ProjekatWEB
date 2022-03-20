import {Kafic} from "./kafic.js";
import { Porudzbina } from "./porudzbina.js";
import {Sto} from "./sto.js";


fetch("https://localhost:5001/Kafic/PreuzmiKafici").then(p=>{
    p.json().then(data=>{
        console.log(data);
        
        data.forEach(kafic=>{
            
            const kafic1=new Kafic(kafic.id,kafic.naziv,kafic.adresa,kafic.kapacitet,kafic.maxLjudi,kafic.maxLokala);
            console.log(kafic.id);
            
          kafic.stolovi.forEach((s,index)=>{
                 kafic1.stolovi[index]=s.brojStola;
                                               
            }); 
            kafic.porudzbine.forEach((s,index)=>{
                 kafic1.porudzbine[index]=s.brojStola;
                
            }); 

            console.log(kafic1);
            kafic1.crtajKafic(document.body);
        });
    });
});