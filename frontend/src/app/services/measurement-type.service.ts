import { MeasurementType } from './../models/measurement-type.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class RecipeService extends BaseService<MeasurementType> {
  constructor(http: HttpClient) {
    super(http, 'https://localhost:5001/api/MeasurementType');
  }
}
