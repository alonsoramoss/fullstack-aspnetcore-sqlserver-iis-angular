import { Component, inject, OnInit } from '@angular/core';
import { AlumnoService } from '../service/alumno.service';
import { alumno } from '../models/alumno.model';
import { alumnoGradoInstruccion } from '../models/alumnoGradoInstruccion.model';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-alumno',
  standalone: true,
  imports: [NgFor],
  templateUrl: './alumno.component.html',
  styleUrl: './alumno.component.css',
})
export class AlumnoComponent implements OnInit {
  alumnoService = inject(AlumnoService)
  alumnoList!: alumno[];
  alumnoGradoInstruccionList!: alumnoGradoInstruccion[];

  
  ngOnInit(): void {
    this.getAlumnos();
    this.getAlumnosGradoInstruccion();
  }

  getAlumnos(){
    this.alumnoService.getAlumnos().subscribe((response) => {
      if(response){
        this.alumnoList = response;
        console.log(this.alumnoList);
        }
      });
  }

  getAlumnosGradoInstruccion(){
    this.alumnoService.getAlumnosGradoInstruccion().subscribe((response) => {
      if(response){
        this.alumnoGradoInstruccionList = response;
        console.log(this.alumnoGradoInstruccionList);
        }
      });
  }
}































