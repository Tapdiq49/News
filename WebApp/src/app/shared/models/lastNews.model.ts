import { ICategory } from "./category.model";


export interface IPhoto {
    orderBy: number;
    main: boolean;
    image: string;
    newsId: number;
    id: number;
}


export interface ILastNews {
    title: string;
    text: string;
    comment: boolean;
    categoryId: number;
    like: number;
    dislike: number;
    view: number;
    videoLink: string;
    photos: IPhoto[];
    mainPhoto: IPhoto;
    category: ICategory;
    id: number;
    createdAt: Date;
}

