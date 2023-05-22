import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, delay, finalize } from 'rxjs';
import { SpinnerService } from '../services/spinner.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: SpinnerService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    //can use spinnerService.show and hide() directly here.
    this.busyService.busy();

    return next.handle(request).pipe(
      delay(2000),
      finalize(() => {
        this.busyService.idle()        
      })
    );
  }
}
