import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AlumnoComponent } from './alumno/alumno.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AlumnoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'DemoSENATI';
  nombre = 'José Alonso Ramos Ramos'
}


































