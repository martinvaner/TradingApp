import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Ticker } from "../interfaces/Ticker";

@Injectable({
    providedIn: 'root',
})
export class HttpService {

    private tradingAppBEAddress = 'http://localhost:8081';

    constructor(private http: HttpClient) {}

    public getUserData(username: string) {
        return this.http.get<Ticker[]>(this.tradingAppBEAddress + "/data/getUserData/" + username);
    }


}