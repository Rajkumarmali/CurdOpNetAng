import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Auth } from './services/auth';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(Auth)
  if(authService.isLogin()){
     const token = localStorage.getItem('token')
      const cloneReq = req.clone({
         headers:req.headers.set('Authorization',`Bearer ${token}`)
      })
      return next(cloneReq);
  } else
    return next(req);
};
