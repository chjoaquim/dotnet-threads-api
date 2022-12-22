using Microsoft.AspNetCore.Mvc;
using poc_carriers_threads.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace poc_carriers_threads.Models
{
    public class BaseController : Controller
    {
        protected JsonResult ReturnOperationResult<T>(Exception ex) where T : Controller
        {

            ResultViewModel resultViewModel = new ResultViewModel();

            resultViewModel.Status = "Error";
            resultViewModel.Data = ex.Data?.Values;


            resultViewModel.Message = "Ops ... Ocorreu um erro. Por favor, tente novamente mais tarde.";            


            return new JsonResult(resultViewModel)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <param name="message">Mensagem de retornor</param>
        /// <param name="statusCode">Status http que a operação deve retornar</param>
        /// <param name="status">Status da operação</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult(string message, string status, HttpStatusCode statusCode)
        {
            ResultViewModel resultViewModel = new ResultViewModel()
            {
                Status = status,
                Message = message
            };

            return new JsonResult(resultViewModel)
            {
                StatusCode = (int)statusCode
            };
        }

        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <param name="message">Mensagem de retornor</param>
        /// <param name="statusCode">Status http que a operação deve retornar</param>
        /// <param name="status">Status da operação</param>
        /// <param name="data">Objeto de retorno da operação</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult(string message, string status, HttpStatusCode statusCode, object data)
        {
            ResultViewModel resultViewModel = new ResultViewModel()
            {
                Status = status,
                Message = message,
                Data = data
            };

            return new JsonResult(resultViewModel)
            {
                StatusCode = (int)statusCode
            };
        }

        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <typeparam name="T">Tipo da controller</typeparam>
        /// <param name="content">Conteúdo retornado pela operação da controller</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult<T>(object content, int rowCount) where T : Controller
        {
            var resultViewModel = new ResultViewModel();

            if (content == null)
            {
                resultViewModel.Status = "Error";

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)HttpStatusCode.NoContent
                };
            }
            else
            {
                resultViewModel.Status = "Success";
                resultViewModel.Data = content;
                resultViewModel.RowCount = rowCount;

                return new JsonResult(resultViewModel)
                {
                    StatusCode = 200,
                    Value = resultViewModel
                };
            }
        }

        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <typeparam name="T">Tipo da controller</typeparam>
        /// <param name="content">Conteúdo retornado pela operação da controller</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult<T>(object content) where T : Controller
        {
            var resultViewModel = new ResultViewModel();

            if (content == null)
            {
                resultViewModel.Status = "Error";

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)HttpStatusCode.NoContent
                };
            }
            else
            {
                resultViewModel.Status = "Success";
                resultViewModel.Data = content;

                return new JsonResult(resultViewModel)
                {
                    StatusCode = 200,
                    Value = resultViewModel
                };
            }
        }


        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <typeparam name="T">Tipo da controller</typeparam>
        /// <param name="content">Conteúdo retornado pela operação da controller</param>
        /// <param name="message">Mensagem de retorno da operação</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult<T>(object content, string message) where T : Controller
        {
            var resultViewModel = new ResultViewModel();

            if (content == null)
            {
                resultViewModel.Status = "Error";

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.NoContent
                };
            }
            else
            {
                resultViewModel.Status = "Success";
                resultViewModel.Data = content;
                resultViewModel.Message = message;

                return new JsonResult(resultViewModel)
                {
                    StatusCode = 200,
                    Value = resultViewModel
                };
            }
        }

        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <typeparam name="T">Tipo da controller</typeparam>
        /// <param name="content">Conteúdo retornado pela operação da controller</param>
        /// <param name="statusCode">Status http que a operação deve retornar em caso de sucesso</param>
        /// <param name="status">Status da operação</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>        /// <summary>

        protected JsonResult ReturnOperationResult<T>(object content, string status, HttpStatusCode statusCode) where T : Controller
        {
            var resultViewModel = new ResultViewModel();

            if (content == null)
            {
                resultViewModel.Status = "Error";

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.NoContent
                };
            }
            else
            {
                resultViewModel.Status = status;
                resultViewModel.Data = content;


                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)statusCode,
                    Value = resultViewModel
                };
            }
        }

        /// <summary>
        /// Ecapsulador do tratamento do retorno da operação das controllers
        /// </summary>
        /// <typeparam name="T">Tipo da controller</typeparam>
        /// <param name="content">Conteúdo retornado pela operação da controller</param>
        /// <param name="status">Status da operação</param>
        /// <param name="statusCode">Status http que a operação deve retornar em caso de sucesso</param>
        /// <param name="message">Mensagem de retorno</param>
        /// <returns>Conteúdo oriundo da operação da controller serializado em json</returns>
        protected JsonResult ReturnOperationResult<T>(object content, string status, HttpStatusCode statusCode, string message, int count) where T : Controller
        {
            var resultViewModel = new ResultViewModel();

            if (content == null)
            {
                resultViewModel.Status = "Error";

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)System.Net.HttpStatusCode.NoContent
                };
            }
            else
            {
                resultViewModel.Status = status;
                resultViewModel.Message = message;
                resultViewModel.Data = content;
                resultViewModel.RowCount = count;

                return new JsonResult(resultViewModel)
                {
                    StatusCode = (int)statusCode,
                    Value = resultViewModel
                };
            }
        }
    }
}