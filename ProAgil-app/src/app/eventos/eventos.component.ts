import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  _filtroLista: string = '';

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: any = [];
  eventos : any = [];
  

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(evento => evento.Local.toLowerCase().indexOf(filtrarPor) !== -1);
  }

  getEventos()
  {
    this.http.get('http://localhost:5000/api/WeatherForecast').subscribe(
      response => {this.eventos = response},
      error => {console.log('Algo de errado não está certo')}
    )
  }
}
