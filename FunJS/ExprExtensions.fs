﻿module internal FunJS.Expr

open Microsoft.FSharp.Quotations

let iter f expr =
   let rec iter expr =
      f expr
      match expr with
      | ExprShape.ShapeVar _ -> ()
      | ExprShape.ShapeLambda(_, expr) -> iter expr
      | ExprShape.ShapeCombination (_, exprs) ->
         exprs |> List.iter iter
   iter expr