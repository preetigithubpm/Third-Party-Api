import { Injectable, Injector } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class InterceptorInterceptor implements HttpInterceptor {

  constructor(private inject:Injector){}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> 
  {

    let token=localStorage.getItem('token');
    let jwtToken=req.clone({
      setHeaders:{
        Authorization:'bearer '+token
      }
    });
    return next.handle(jwtToken);

  }
}
