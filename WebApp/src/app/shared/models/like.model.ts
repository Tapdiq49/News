import { ICategory } from "./category.model";

export interface IPhoto {
    orderBy: number;
    main: boolean;
    image: string;
    newsId: number;
    id: number;

}

export interface INewsLike {
    title: string;
    text: string;
    comment: boolean;
    categoryId: number;
    like: number;
    dislike: number;
    view: number;
    videoLink?: any;
    createdAt: Date;
    photos: IPhoto[];
    category: ICategory;
    id: number;
}

