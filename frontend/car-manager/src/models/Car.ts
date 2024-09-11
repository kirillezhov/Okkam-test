import { Brand } from './Brand.ts';
import { BodyType } from './BodyType.ts';

export interface Car {
    id: string;
    modelName: string;
    createdAt: Date;
    seatsCount: number;
    url?: string;
    brand: Brand;
    bodyType: BodyType;
}