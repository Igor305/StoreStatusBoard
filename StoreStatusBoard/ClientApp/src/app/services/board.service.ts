import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ResponseModel } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private http: HttpClient, private router: Router) { }

  public async getBoard(): Promise<ResponseModel> {
    const url: string = "https://localhost:44341/api/Board";
    const board = await this.http.get<ResponseModel>(url).toPromise();

    return board;
  }
}
