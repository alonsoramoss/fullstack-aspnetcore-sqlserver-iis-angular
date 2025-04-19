import { inject, Injectable } from '@angular/core'; 
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http'; 
import { map, Observable } from 'rxjs';
import { environment } from "../environments/environment.development";
import { alumno } from '../models/alumno.model';
import { alumnoGradoInstruccion } from '../models/alumnoGradoInstruccion.model';

@Injectable ({
    providedIn: 'root'
})
export class AlumnoService {
    private httpClient = inject(HttpClient)
    private urlBase = environment.apiUrl;
    constructor() { }

    getHeaders(){
        return new HttpHeaders({
            'Content-Type': 'application/json',
        })
    }

    public getAlumnos(): Observable<any> {
        return this.httpClient.get<any>(this.urlBase + '/Alumno/ListarAlumnos', { headers: this.getHeaders() })
        .pipe(
            map((response: alumno) => {
                if (response == null) return null;
                return response;
            })
        )
    }

    public getAlumnosGradoInstruccion(): Observable<any> {
        return this.httpClient.get<any>(this.urlBase + '/Alumno/ListarAlumnosGradoInstruccion', { headers: this.getHeaders() })
        .pipe(
            map((response: alumnoGradoInstruccion) => {
                if (response == null) return null;
                return response;
            })
        )
    }
}
























