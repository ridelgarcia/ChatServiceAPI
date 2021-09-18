using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services.Interfaces
{
    public interface IChatService
    {
        Task<SendMessageResponse> SendMessage(SendMessageRequest requestData);
    }
}