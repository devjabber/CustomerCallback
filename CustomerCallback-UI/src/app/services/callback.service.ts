import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CallbackNew } from '../models/CallbackNew';
import { environment } from '../../environments/environment';
import { CallbackNewPayload } from '../models/CallbackNewPayload';
import { CallbackView } from '../models/CallbackView';

@Injectable({
  providedIn: 'root',
})
export class CallbackService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  addCallback(callbackNew: CallbackNew) {
    const callBackHours = callbackNew.callbackTime.split(':')[0];
    const callBackMinutes = callbackNew.callbackTime.split(':')[1];
    const dateString = `${callbackNew.callbackDate}T${callBackHours}:${callBackMinutes}:00`;
    const callBackDateTime = new Date(dateString);

    const callbackPayload: CallbackNewPayload = {
      firstName: callbackNew.firstName,
      lastName: callbackNew.lastName,
      mobileNumber: callbackNew.mobileNumber,
      callbackDateTime: callBackDateTime,
    };

    return this.http.post<CallbackNewPayload>(
      this.baseUrl + 'api/customercallback',
      callbackPayload,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      }
    );
  }

  getAllCallbacks(): Observable<CallbackView[]> {
    return this.http.get<CallbackView[]>(this.baseUrl + 'api/customercallback');
  }
}
