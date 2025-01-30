import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { map, Observable, of, switchMap, tap } from 'rxjs';
import { Matches } from '../matches/matches/models/matches-model';
import { Teams } from './models/teams-model';


@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  // headers: HttpHeaders = new HttpHeaders().set('X-Auth-Token', environment.apiKey);

  constructor(private http: HttpClient) { }

  getTeams(): Observable<Teams[]> {

      return this.http.get<Teams[]>(`https://localhost:7219/api/Team`);

  }

  
}
