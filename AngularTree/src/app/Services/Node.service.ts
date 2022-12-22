import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, pipe, throwError } from 'rxjs';
import {Node} from '../Classes/Node';

@Injectable({
  providedIn: 'root'
})
export class NodeService{

  //Request INFO
  private URL = "http://localhost:5132/api/Nodes/";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  // Get Instance from HttpClient
  constructor(public http:HttpClient) { }


  // Return all Nodes
  GetAllNodes():Observable<Node[]>{
    return this.http.get<Node[]>(this.URL)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  // Return Node
  GetNode(id:string):Observable<Node>{
    return this.http.get<Node>(this.URL+id)
    .pipe(
      catchError(this.errorHandler)
    )
  }


  // insert new node
  AddNode(node:Node){
    return this.http.post(this.URL ,JSON.stringify(node) ,this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }


  // Edit Node
  UpdateNode(id:string , node:Node){
    return this.http.put(this.URL+id , node , this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  // Delete Node
  DeleteNode(id:string){
    return this.http.delete(this.URL+id , this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  // Handel Errors
  errorHandler(error:any){
    let errorMessage = "";
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.massage;
    }else{
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage)
  }

}
