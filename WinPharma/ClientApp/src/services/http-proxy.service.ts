import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, observable } from 'rxjs';
import { DataModel } from 'src/models/data.model';
import { GoodRequestModel } from 'src/models/good-request.model';
import { GoodResult, GoodResultData } from 'src/models/good-result.model';

@Injectable({
  providedIn: 'root'
})
export class HttpProxyService {

  constructor(@Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

  public getData(request: GoodRequestModel): Observable<GoodResult> {
    return this.http.post<GoodResult>(this.baseUrl + 'common/GetGoods', request);
  }

}
