import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StoreModel } from '../models/store.model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private http: HttpClient, private router: Router) { }

  public async getBoard() {
    const url: string = "https://localhost:44341/api/Board";
    const board = await this.http.get<Array<StoreModel>>(url).toPromise();

    return board;
  }
}
