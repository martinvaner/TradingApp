import { Analytics } from "./Analytics";
import { Price } from "./Price";

export interface Ticker {
    symbol: string;
    prices: Price[];
    analytics: Analytics;
}